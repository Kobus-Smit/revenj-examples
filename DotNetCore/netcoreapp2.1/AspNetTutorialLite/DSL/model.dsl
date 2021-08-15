module tutorial 
{
	aggregate Customer(id) {
		string(20) id;
		string name;
	}

	snowflake<Customer> CustomerList {
		id;
		name;
	}
}