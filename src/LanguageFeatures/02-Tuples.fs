module LanguageFeatures.Tuples

open System
open Xunit

// Ah tuples, beautiful right...
// ref: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/tuples
[<Fact>]
let ``#2.1, a simple tuple`` () =
    let myTuple = ("John", 77)
    // TODO: replace the values below by the respective values from the tuple.
    // Don't use destructing, keep myTuple as is.
    let firstPart = failwith "TODO: implement!" // `failwith` generates an F# exception, https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/exception-handling/the-failwith-function
    let secondPart = failwith "TODO: implement!" // We want the test to fail at first as there is no implementation provided.

    Assert.Equal("John", firstPart)
    Assert.Equal(77, secondPart)

[<Fact>]
let ``#2.2, ignoring parts of a tuple`` () =
    // In this sample `year` is not being used.
    // F# tooling should give you a visual clue or a warning about this.
    // TODO: get rid of the warning without changing the right part.
    let name, year = ("Strawberry Fields", 1976)
    Assert.Equal("Strawberry Fields", name)

[<Fact>]
let ``#2.3, C# interop and tuples`` () =
    // Tuple members are separated with `,`.
    // Coming from C# this can appear very confusing.
    // String.Split take a tuple as argument in this case, the tuple itself is wrapped in parenthesis.
    let pieces =
        "Penny Lane"
            .Split([| " " |], StringSplitOptions.RemoveEmptyEntries)

    Assert.Equal("Penny", pieces.[0])

[<Fact>]
let ``#2.4, tuple type definition`` () =
    // Notice that for tuple definitions we use `*`, but for assignment we use `,`
    let album : string * int = "A Hard Day's Night", 1964
    Assert.Equal(("A Hard Day's Night", 1964), album)
