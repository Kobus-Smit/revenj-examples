# revenj-examples

This repo contains some C# WinForms, Visual Studio 2017, PostgreSQL 9.6 demo/example apps that I wrote while learning the cool [DSL Platform](https://dsl-platform.com/) / [Revenj](https://github.com/ngs-doo/revenj) and while having questions for the Revenj team.

# Use case 1

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
    int RegistrationNumber { unique; }
    detail<Submission.Customer> Submissions; 
  }

  guid aggregate Submission {
    Customer *Customer;
    Form *Form;
    string Comments;
    timestamp Date { versioning; }
  }

  snowflake<Submission> SubmissionList {
    Customer.Name as Customer;
    Form.Name as Form;
    Form.Group.Name as Group;
    Date;
    order by Customer;
  }


  snowflake<Submission> SelectedSubmission {
    Customer.Name as Customer;
    Form.Name as Form;
    Form.Schema as Schema;
    Form.Inputs as FormInputs;
    Form.Group.Name as Group;
    Comments;
    Date;

    specification Where 'it =>  it.URI == uri' {
      string uri;
    }
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
