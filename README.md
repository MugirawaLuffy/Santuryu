# Santōryū

Nils C# compiler:
Now on master!
functionality so far:
one string input,
lexing, parsing, evaluating for primitive operators
supported types: int and bool

Also, after the merging of UnitTests to master, master now
has the ability to compile the project by typing ./build.cmd
In this script, we make sure our project is buing build and tested
against the unit tests we implemented. As is, the branch UnitTests
did not add new further capabilities to the compiler itself, making it 
big waste of time. 
up to this point, emplementing UnitTests was my least fav thing to do,
hope it pays off!
