module LanguageFeatures.Operators

open Xunit
open System

(*
    In F# it is easy to create custom operators.
    They can lead to very expressive code.
    Let's start first with two popular built-in operators: (|>) and (>>)
    ref: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/functions/#function-composition-and-pipelining
*)

[<Fact>]
let ``#6.1, meeting the pipe operator`` () =
    // The pipe operator allows us to pass an expression as last argument of the next function
    let dateToString (d: DateTime) = d.ToString("dddd")
    let toUpper (n: string) = n.ToUpper()

    // you need to read this from right to left
    let expected = toUpper (dateToString DateTime.Now)

    // while this reads from left to right, top to bottom
    let todayButInCapitals = DateTime.Now |> dateToString |> toUpper

    Assert.Equal(expected, todayButInCapitals)

[<Fact>]
let ``#6.2, compose functions`` () =
    // When the result of a function is the input of another function, those functions can be combined to a new function.
    // F. ex:

    // DateTime -> string
    let dateToString (d: DateTime) = d.ToString("dddd")
    // string -> int
    let length (n: string) = n.Length

    // DateTime -> int
    let lengthOfDayName = dateToString >> length

    let expected = length (dateToString DateTime.Now)
    let actual = lengthOfDayName DateTime.Now

    Assert.Equal(expected, actual)

[<Fact>]
let ``#6.3, custom operator`` () =
    // TODO: create a new operator /+/ that counts a + b + 1
    // ref: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/operator-overloading#creating-new-operators
    let a = 7
    let b = 2
    let result = a + b // TODO use custom operator instead of +
    Assert.Equal(10, result)

[<Fact>]
let ``#6.4, assert operator`` () =
    let a = 5
    // TODO: create an custom operator ==, that will execute Assert.Equal on two values.
    Assert.Equal(5, a)
