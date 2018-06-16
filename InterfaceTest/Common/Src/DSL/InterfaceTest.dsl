module InterfaceTest {

root Person {
	string Name;
	implements c# 'InterfaceTest.App.Common.Interface.IPerson';

	specification FindByName 'it => it.Name == name' {
		string name;
	}
}

}
