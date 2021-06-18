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
    let firstPart = "Paul"
    let secondPart = 75

    Assert.Equal("John", firstPart)
    Assert.Equal(77, secondPart)

[<Fact>]
let ``#2.2, ignoring parts of a tuple`` () =
    // In this sample `year` is not being used.
    // F# tooling should give you a visual clue or a warning about this.
    // TODO: get rid of the warning without changing the right part.
    let (name, year) = ("Strawberry Fields", 1976)
    Assert.Equal("Strawberry Fields", name)

[<Fact>]
let ``#2.3, C# interop and tuples`` () =
    // Tuple members are separated with `,`.
    // Coming from C# this can appear very confusing.
    // String.Split take a tuple as argument in this case
    let pieces =
        "Penny Lane"
            .Split([| " " |], StringSplitOptions.RemoveEmptyEntries)

    Assert.Equal("Penny", pieces.[0])

type Album = (string * int) // We can alias a tuple definition in F#.
let someAlbum : Album = ("A Hard Day's Night", 1964) // The : Album is not necessary in this case
// Notice that for tuple definitions we use *, but for assignment we use ,
