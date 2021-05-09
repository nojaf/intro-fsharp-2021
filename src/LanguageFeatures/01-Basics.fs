module LanguageFeatures.Basics

open Xunit // open means using in C#, ref: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/import-declarations-the-open-keyword

(*

Hello there, complete the unit tests to learn more about the F# language.
Some tests will already pass as is, some will need additional code.

The goal is to learn the language feature of F#.
Sometimes some additional research will be required.
If that is the case link will provided.

*)

(*
    Before you begin, comment in F# are written in two format:
    - // line-comment
    - (* *) block comment
*)


(*

Ah the first unit test.
We can see that the `let` keyword is used to declare both functions and values.
ref: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/functions/let-bindings

Identifiers can be one word of a sentence between backticks `` ``.

The unit test is annotated with a [<Fact>] attribute (from XUnit).
ref: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/attributes

Lastly the () symbol at the end is called unit.
Unit semantically means the same thing as void in C# however it is a concrete type.
ref: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/unit-type

*)
[<Fact>]
let ``a first unit test to get things started`` () =
    let a = true // without telling the compiler it can infer that a is a boolean. Because the keyword true and false can only be interpreted as boolean.
    let b = false

    Assert.Equal(a, b) // We can use Assert.Equal from the xUnit namespace because of the `open` statement above.

[<Fact>]
let ``simple if / else structure`` () =
    let a = true
    // Notice how the declaration of value b can be a multiple line expression.
    let b =
        if a then
            "a was true"
        else
            "a was false"
    // b was also inferred as string so the .Length function is available.
    let length = b.Length
    Assert.Equal(11, length)

[<Fact>]
let ``if / else if / elif / else`` () =
    let numbers = [| 1 .. 100 |] // creates an array with elements from 1 to 100 (boundaries inclusive).

    // This is an inner function, scoped to the current test.
    let parseNumber n =
        let isFizz = n % 3 = 0 // notice that we can compare value/expression in F# with a single `=` instead of `==` or `===`.
        let isBuzz = n % 5 = 0

        if isFizz && isBuzz then
            "FizzBuzz"
        // `elif` and `else if` mean exactly the same thing.
        // ref: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/conditional-expressions-if-then-else
        elif isFizz then
            "Fizz"
        else if isBuzz then
            "Buzz"
        else
            // string function: Converts the argument to a string using ToString.
            // See https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators.html#string
            string n

    // TODO: populate the fizzBuzz with result of calling each item of number with the parseNumber function
    // For now it us ok to mutate the array
    // You can assign value to an index with <-, f.ex fizzBuzz.[0] <- "meh"
    let fizzBuzz : string array = Array.zeroCreate 100

    let firstFizz = fizzBuzz.[2]
    let firstBuzz = fizzBuzz.[4]
    let firstFizzBuzz = fizzBuzz.[14]

    Assert.Equal("Fizz", firstFizz)
    Assert.Equal("Buzz", firstBuzz)
    Assert.Equal("FizzBuzz", firstFizzBuzz)

[<Fact>]
let ``the mutable keyword`` () =
    // F# is not a pure strict functional language
    // Since there is interopt with C# you can mutable variables by using the `mutable` keyword.
    // Avoid this at all time ;)
    let mutable two = 1

    // TODO: change the value of variable two to 2.
    // ref: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/values/#mutable-variables

    Assert.Equal(2, two)

[<Fact>]
let ``while loops`` () =
    // Uncommon in F# but you can use while loops
    let mutable a = 0

    // TODO: write a while loop that increase by 1 a until it becomes 10.
    // ref: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/loops-while-do-expression

    Assert.Equal(10, a)

[<Fact>]
let ``first lambda`` () =
    // You can use the `fun` keyword to write lambda's.
    // Mind the -> instead of C#'s =>
    // TODO: complete the lambda so that the value is returned in uppercase.
    let toUpperCase = fun a -> a
    // ref: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/functions/lambda-expressions-the-fun-keyword

    let name = "Joey"
    let uppercased = toUpperCase name
    Assert.Equal("JOEY", uppercased)
