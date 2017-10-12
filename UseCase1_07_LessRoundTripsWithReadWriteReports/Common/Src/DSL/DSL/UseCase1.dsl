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
