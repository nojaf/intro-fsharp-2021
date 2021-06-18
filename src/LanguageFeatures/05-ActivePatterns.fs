module LanguageFeatures.ActivePatterns

open Xunit

(*
With Discriminated Unions should dived a type into one or more types.
It is also possible to constraint existing types to one or more categories with Active Patterns.
ref: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/active-patterns
*)

[<Fact>]
let ``#5.1, fizzbuzz with active patterns`` () =
    let (|Fizz|Buzz|FizzBuzz|Number|) (input: int) =
        let isFizz = (input % 3) = 0
        let isBuzz = (input % 5) = 0

        if isFizz && isBuzz then FizzBuzz
        elif isFizz then Fizz
        elif isBuzz then Buzz
        else Number input

    let numbers = [| 1 .. 15 |]

    let processNumber (n: int) : string =
        // TODO: match the newly created active pattern
        match n with
        | Fizz -> "fizz"
        | Buzz -> "buzz"
        | FizzBuzz -> "fizzbuzz"
        | _ -> string n

    let result = Array.map processNumber numbers

    Assert.Equal("fizz", result.[2])
    Assert.Equal("buzz", result.[4])
    Assert.Equal("7", result.[6])
    Assert.Equal("fizzbuzz", result.[14])

[<Fact>]
let ``#5.2, non empty list`` () =
    // TODO: implement the follow partial active pattern
    // Return `Some items` when the list is not empty
    let (|NonEmptyList|_|) (items: 't list) =
        match items with
        | [] -> None
        | _ -> Some items

    let values = [ 1; 2; 4; 8 ]

    let length =
        match values with
        | NonEmptyList v -> List.length v
        | _ -> 0

    Assert.Equal(4, length)
