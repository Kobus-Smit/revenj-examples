module SimpleMapping {

root Person {
	string Name;
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

mapping ToVM { identical; }  
mapping FromVM { identical; }  
  
}
