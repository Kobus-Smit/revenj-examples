module SimpleMapping {

root Person {
	string Name;
	Gender Gender;
}

struct PersonVM {
	string Name;
	has mapping ToVM from Person;
	has mapping FromVM into Person;
}

struct CommonParam
{
	PersonVM Person;
	bool Other1;
}

enum Gender {
	Male;
	Female;
}

mapping ToVM { identical; }  
mapping FromVM { identical; }  
  
}
