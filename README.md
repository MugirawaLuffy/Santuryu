#Santōryū

is a compiler that compiles the ryu language down to C#IL. To do that, you just have to write a .ryu program file (valid instructions, keywords and operation will be explained in a later section), and compile it down.
Santuryu/Ryu (I use both interchangebly), is a language designed to be both easy and effective, without compromising on features like types experienced programmers often miss when working with languages like python.

#Compiling .ryu files

The easier way to compile the language is to write a program (e.g helloWorld.ryu) and save it. Then hit f1 in code (you need to have the Repo opened in code as this behaviour is added in "tasks.json") and select "sc" which stands for SanturyuCompiler. I therefore like to place my Santuryu code into ./CodeSamples, but the file location does not matter to the task.
The other way is a little harder, not because of the way itself but because of how hidden this feature is nowadays.
Click on the "File" tab in the upper left corner, then >preferences>KeyboardShortcuts. This will open a settings page where you can see all shortcuts. Pressing the three horizontal dots in the upper right corner of the Keyboard Shortcuts settings page, and select "Show User Keybindings". Now a list with all your custom shortcuts should pop up, or is empty if you have none. Next to the three dots you clicked on earlier are a few other Icons, click the one that resembles a page. This will open a .json resemblance of your custom shortcuts. Inside the square brackets you now should place this:

{
"key": "ctrl+alt+m",
"command": "workbench.action.tasks.runTask",
"args": "sc"
},

Now you can compile a .ryu file just by hitting ctrl+alt+m.

#Basic operations
As every programming language, Santuryu offers basic logic and calculation operations such as +/-/\*/%, || or && and == or != and more. Also, the last evaluation is being written at the end of the compilation, so a simple statement like "2 == 2" will output true to the console.

#Advanced mechanisms
Just a short list and function of symbols and identifiers. This is no tutorial!

##Variables

- the keyword "var" will declare a variable that is both readable and writable. As of now, it has to be initialized when declared: var a = 0
- the keyword "let" will declare a "constant", which means you can give it a value once but not change it later: let limit = 10
- types: Seeing the example of the two declaration keywords, you might see that you do not need to type the variable explicitly as this is automatically done by the binder in the compilation process. You have, however, the freedom to do so if you want, if it's required or if it just makes code clearer for you: var name : string = "You name"

##conditional statements

- the keyword if let's you evaluate logical statements and jump accordingly:
- else works after if and in combination with else if
  {
  var a : number == 2
  if a < 18
  print("You are to young to go the club")
  else if(a >= 21)
  print("Unrestricted acces to the club")
  else
  print("normal access")
  }

The indetation in README.mds is hard ot understand, but this example should be enough to make you accustomed to the syntax

##Loops
-while (condition)
//code

do
//code
while (condition)

-for statements: While the other loops are rather intuitive, for is a little harder:
let limit : int = 10
for i = 0 to limit
//code

i = 0 declares an iterrator i that counts up every time the loop repeats, you can access it as a variable

-break and continue can exit a loop or overgo a revoultion
##scopes
Of course the mechanisms work with scopes: While the previous for loop only let you execute one single line of code
for ...
{
//code
//code
}

let's you write bigger logic

#Functions
Help you to outsource repeating code into recallable procedures/functions

##function calls
Just write \[functionname\]() to call a function. Builtin functions are:
-input(), gets input from the console
-print(), prints a line to the console
-rnd(upperBound) returns a random number from 0 to upperBound

##function declaration
Syntax necessarry to write own functions, is started via the "function" keyword

###procedures (have no return)
function \[functionName\](arguments)
{
code without return
}
###functions (actually return things)
function \[functionName\](arguments) :returntype
{
code
return x
}

###example

function greet(name: string) : string
{
return "hello " + name + "!"
}

#ControlFlowGraph
When compiling a ryu program or interpreting with si.cmd, a CFG is generated at "si/bin/Debug/net5.0/cfg.dot". You can open the .dot file in a browser to see the logic of your program presented in a FlowChart.

arguments have to have explicit types and are seperated via comma.

#Last words
I don't want to see bad code with Santuryu!
