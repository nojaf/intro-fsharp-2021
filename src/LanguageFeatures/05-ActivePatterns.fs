module LanguageFeatures.ActivePatterns

open Xunit

(*
With Discriminated Unions should dived a type into one or more types.
It is also possible to constraint existing types to one or more categories with Active Patterns.
ref: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/active-patterns
*)

[<Fact>]
let ``fizzbuzz with active patterns`` () =
    // TODO: complete the active pattern
    // Once completed the compiler might be able to infer the Choice<unit,unit,unit,int> part.
    let (|Fizz|Buzz|FizzBuzz|Number|) (input: int) : Choice<unit, unit, unit, int> = Number input
    let numbers = [| 1 .. 15 |]

    let processNumber n =
        // TODO: match the newly created active pattern
        match n with
        | _ -> ""

    let result = Array.map processNumber numbers

    Assert.Equal("fizz", result.[2])
    Assert.Equal("buzz", result.[4])
    Assert.Equal("6", result.[5])

[<Fact>]
let ``non empty list`` () =
    // TODO: implement the follow partial active pattern
    // Return `Some items` when the list is not empty
    let (|NonEmptyList|_|) (items: 't list) = failwith "not implemented"

    let values = [ 1; 2; 4; 8 ]

    let length =
        match values with
        | NonEmptyList v -> List.length v
        | _ -> 0

    Assert.Equal(4, length)
