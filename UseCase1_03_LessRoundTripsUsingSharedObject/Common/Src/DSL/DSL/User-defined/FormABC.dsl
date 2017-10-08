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