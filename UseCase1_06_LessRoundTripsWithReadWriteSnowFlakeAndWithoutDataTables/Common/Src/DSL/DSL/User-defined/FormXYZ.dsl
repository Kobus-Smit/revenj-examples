module FormXYZ  {

  guid aggregate Input {
    UseCase1.Submission *Submission;
    datetime LastPurchase;
    string JKhdk;
    int Qjfs;

    specification Where 'it =>  it.SubmissionURI == submissionURI' {
      string submissionURI;
    }
  }

  guid aggregate Output {
    UseCase1.Submission *Submission;
    int Rgflkj;
    decimal XYZ;
  }
}