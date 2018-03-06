module Test {

root XYZ(UserID, A, Type) {
  User *User;
  string A;
  EnumX Type;
  ABC(A,Type) *ABC;
}

snowflake<XYZ> XYZs {
  User.Name;
  A;
  Type;
}

root ABC(A, Type) {
  string A;
  EnumX Type;
}

enum EnumX {
  E1;
  E2;
}  

root User(Name) {
  string Name;
}

}



/*
module Test {

aggregate XYZ(Type) {
  EnumX Type;
}

snowflake<XYZ> XYZs {
  Type;
}

enum EnumX {
  E1;
  E2;
}  

}
*/

/*
module Test {

aggregate XYZ { 
	string From;

	specification FindBy 'it => it.From == for' {
		string for;
	}
}
}
*/

/*
module Tutorial {
  aggregate Example {
    timestamp StartedOn;
    string CodeName;
    Set<string(10)> Tags;
    List<Idea> Ideas;
    persistence { history; }
  }
  value Idea {
    date? ETA;
    Importance Rating;
    decimal Probability;
    string[] Notes;
  }
  enum Importance {
    NotUseful;
    GroundBreaking;
    WorldChanging;
  }
  snowflake<Example> ExampleList {
    StartedOn;
    CodeName;
    order by StartedOn desc;
  }
}
*/