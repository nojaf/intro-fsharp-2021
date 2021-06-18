module LanguageFeatures.Records

open System
open Xunit

// This is a record definition
// A record is a data structure similar to a class in C#
// However, you always need to assign all members. It has an explicit constructor behind the scenes.
// You can't update the fields without creating a new record.
// ref: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/records
type Album = { Name: string; ReleaseYear: int }

[<Fact>]
let ``#3.1, basic records`` () =
    // The instance of a record looks pretty similar.
    // Try to remove on of the members, the compiler will prompt an error.
    let firstRecord =
        { Name = "My Bonnie"
          ReleaseYear = 1962 }

    Assert.Equal(1962, firstRecord.ReleaseYear)

[<Fact>]
let ``#3.2, update a record`` () =
    let record = { Name = "1"; ReleaseYear = 2001 } // notice how the member can be put on a single line if you separate them with a `;`.
    // In fact the `;` in F# indicates as a newline in certain scenario's. More on that when we get to lists.

    let correctedRecord = { record with ReleaseYear = 2000 } // TODO: update the ReleaseYear to 2000
    Assert.Equal(2000, correctedRecord.ReleaseYear)

type Artist =
    { FirstName: string
      LastName: string }

    // Records can also have members.
    // The this word is an identifier that represents the instance.
    // You could have also chosen banana as identifier.
    member this.FullName = this.FirstName + " " + this.LastName

[<Fact>]
let ``#3.3, call member on record instance`` () =
    let john =
        { FirstName = "John"
          LastName = "Lennon" }

    Assert.Equal("John Lennon", john.FullName)

type Infant = { Name: string; Age: int }

[<Fact>]
let ``#3.4, compare records`` () =
    let infants =
        [ { Name = "Dexter"; Age = 6 }
          { Name = "Alex"; Age = 8 }
          { Name = "Bob"; Age = 7 } ]
        |> List.sort

    let firstItem = infants.[0]

    // TODO: Why does this work in the first place?
    // See https://fsharpforfunandprofit.com/posts/records/#record-equality
    let hashCode = firstItem.GetHashCode()

    let comparedToSecondItem =
        (firstItem :> IComparable)
            .CompareTo(infants.[2] :> IComparable)

    Assert.Equal("Alex", firstItem.Name)

[<Fact>]
let ``#3.5, anonymous records`` () =
    // Since F# 4.7 is possible to declare a record without first defining a type.
    // ref: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/anonymous-records
    let john =
        {| Name = "John Lennon"
           Instrument = "Keyboard / Guitar" |}

    Assert.Equal("John Lennon", john.Name)
