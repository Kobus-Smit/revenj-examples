module InterfaceTest {

root Person {
	implements c# 'InterfaceTest.IPerson';

	string Name;
	
	specification FindByName 'it => it.Name == name' {	string name;  }
}

}
