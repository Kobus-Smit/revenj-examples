# revenj-examples

This repo contains some C# WinForms, Visual Studio 2017, PostgreSQL 9.6 demo/example apps that I wrote while learning the cool [DSL Platform](https://dsl-platform.com/) / [Revenj](https://github.com/ngs-doo/revenj) and while having questions (see [#89](https://github.com/ngs-doo/revenj/issues/89)) for the Revenj team.

## [Runnable Revenj tutorial example](https://github.com/Kobus-Smit/revenj-examples/tree/master/RevenjTutorial1)
A runnable example of the first basic Revenj tutorial found at https://github.com/ngs-doo/revenj/blob/master/tutorials/revenj-tutorial-setup.md

## Use case 1

- Use case 1 is an example of loading and saving aggregates, using snowflakes, specifications, server commands etc.
I like how quick it is to evolve the model and that there's not a lot of boilerplate code to maintain.

- Use case 1 does however work with some dynamic data where the model is not known at design time. It is a simplified example of a real project's requirements. So the examples partly uses Revenj's models and then DataTables for the dynamic data. (It would probably be possible to use Revenj for the dynamic part as well but that would involve compiling the dsl to dlls using the dsl-compiler and dynamically loading those dlls.)

### Instructions
1. Run [RecreateDatabase.bat](https://github.com/Kobus-Smit/revenj-examples/blob/master/UseCase1_01_ThreeRoundTrips/Back-end/Database/_RecreateDatabase.bat) to create the Postgres database and the required schemas/tables/etc.

2. Run the solution to launch the HTTP Server and the client app 

3. Click the "Create Demo Data" button to insert some demo data

4. Click the "Open Submission" button, open any entry, enter some data in the Inputs grid and Save.

## UseCase1_01_ThreeRoundTrips 

This version calls a "Load" Server Command that returns an updateable aggregate.
A possible concern is that the Client need to do 3 more [round trips](https://github.com/Kobus-Smit/revenj-examples/blob/faee70e6c90fade6b377bd2e4e94073f182c8f16/UseCase1_01_ThreeRoundTrips/Front-end/Src/Forms/EditSubmissionForm.cs#L25
) to display all the required information: 


## UseCase1_02_LessRoundTripsButSnowFlakeIsReadOnly 

This version uses a snowflake and does need to do those 3 roundtrips.
But the problem is then my ["Save"](https://github.com/Kobus-Smit/revenj-examples/blob/faee70e6c90fade6b377bd2e4e94073f182c8f16/UseCase1_02_LessRoundTripsButSnowFlakeIsReadOnly/Back-end/Src/ServerCommand/SaveSubmission.cs#L23) Server command does not work because snowflakes are readonly. 


## UseCase1_03_LessRoundTripsUsingSharedObject

This also do not need those 3 roundtrips and it can save changes back to the database. It uses a snowflake and also an writable POCO object shared between the client and the service. But it does require more boilerplate code and AutoMapper.


## UseCase1_04_LessRoundTripsSend3ExtraObjects

This case is very similiar to UseCase1_01_ThreeRoundTrips but it adds 3 extra parameters and does not need roundtrips then. The tuple parameter does not look very neat...


## UseCase1_05_LessRoundTripsWithReadWriteSnowFlake

This one works nice, less boilerplate code compared to UseCase1_04_LessRoundTripsSend3ExtraObjects. But it required me to modify the source code that Revenj generates, removing internal from the setters to create mutable snowflakes. See [comment-335050682](https://github.com/ngs-doo/revenj/issues/89#issuecomment-335050682)


## UseCase1_06_LessRoundTripsWithReadWriteSnowFlakeAndWithoutDataTables

This WIP tries to get rid of the DataTables and uses IDomainModel (see [comment-335018469](https://github.com/ngs-doo/revenj/issues/89#issuecomment-335018469))

## UseCase1_07_LessRoundTripsWithReadWriteReports

This is the best solution so far with the least boilerplate code. It uses the report concept as suggested by @zapov so it "preloads/prefetches". However, same problem than UseCase1_05_LessRoundTripsWithReadWriteSnowFlake, because reports are not mutable. I've modified the Revenj generate source code and added a [DataMember](https://github.com/Kobus-Smit/revenj-examples/blob/13560da7f15eedc60a6eb39302f2c3d95ae619ab/UseCase1_07_LessRoundTripsWithReadWriteReports/TempTest/DOTNET_CLIENT/global__UseCase1.Submission.cs#L180
) attribute and then it worked fine.

## Requirement/Specifications:

- A Submission is the result of a Customer completing and submitting a Form
- A Form has a user defined list of Input Entries and Output Entries
- A Form belongs to a FormGroup
- The Customer's Inputs and Outputs of a Submission must be stored in a database table in a schema per Form.


### Application DSL:

```
module UseCase1  {

  guid aggregate FormGroup {
    string Name { unique; }
    detail<Form.Group> Forms; 
  }

  guid aggregate Form {
    string Name { unique; }
    string Schema { unique; }
    FormGroup *Group;
    FormStatus Status;
    List<Entry> Inputs;
    List<Entry> Outputs;
    detail<Submission.Form> Submissions; 
    calculated int SubmissionsCount from 'm => m.Submissions.Count()';
  }

  snowflake<Form> FormList {
    Name;
    Group.Name as Group;
    Status;
    SubmissionsCount;
    order by Name;
  }

  value Entry {
    string Description;
    string ColumnName;
    DataType DataType;  
  }

  enum DataType {
    String;
    Int;
    Decimal;
    Bool;
    DateTime;
  }

  enum FormStatus {
    New;
    PendingApproval;
    Approved;
    NotApproved;
    Archived;
  }

  guid aggregate Customer {
    string Name;
	string Email;
    int RegistrationNumber { unique; }
    detail<Submission.Customer> Submissions; 
  }

  guid aggregate Submission {
    Customer *Customer;
    Form *Form;
    string Comments;
    timestamp Date { versioning; }
    Binary InputsBytes;
    Binary OutputBytes;
  }

  snowflake<Submission> SubmissionList {
    Customer.Name as Customer;
    Form.Name as Form;
    Form.Group.Name as Group;
    Date;
    order by Customer;
  }

  report SelectedSubmission {
    string uri;
	Submission Submission 'it => it.URI == uri';
  }
}

```

### Example of user defined dynamically generated Form DSL:
```
module FormABC  {

  guid aggregate Input {
    UseCase1.Submission *Submission;
    int BirthYear;
    int NumberOfCars;
  }

  guid aggregate Output {
    UseCase1.Submission *Submission;
    decimal ABC;
    decimal XYZ;
    bool HasQQQ;
  }
}
```
