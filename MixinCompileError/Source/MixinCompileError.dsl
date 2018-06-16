module Test {

mixin MyMixin {
	string ABC;
}

root MyRoot { 
	has mixin MyMixin;
}

}
