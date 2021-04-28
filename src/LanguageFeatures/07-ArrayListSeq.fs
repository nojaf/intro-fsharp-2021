module LanguageFeatures.ArrayListSeq

open System
open System.Globalization
open Xunit

(*

Collections are heavily used in F#.
Lists being the most prominent one.
ref: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/lists#module-functions
ref: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/arrays
ref: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/sequences

*)

[<Fact>]
let ``first item of the list`` () =
    let numbers = [ 0; 1; 2; 3 ]
    let head = Int32.MaxValue // TODO replace with the first element of the list
    Assert.Equal(0, head)

[<Fact>]
let ``first item of the list, safely`` () =
    let letters = [ 'a'; 'b'; 'c'; 'd' ]
    let otherLetters = []

    let firstLetterAsCapital letters = String.Empty // TODO: complete function

    Assert.Equal("A", firstLetterAsCapital letters)
    Assert.Equal("?", firstLetterAsCapital otherLetters)

[<Fact>]
let ``map dates to string`` () =
    let dates =
        [ DateTime(1997, 4, 17)
          DateTime(2005, 7, 13)
          DateTime(2011, 5, 6) ]
    // TODO: map the dates to the correct string format
    // Hint: you might need CultureInfo.InvariantCulture
    let datesAsString : string list = []

    Assert.Equal<string list>(
        [ "Thursday April 1997"
          "Wednesday July 2005"
          "Friday May 2011" ],
        datesAsString
    )

[<Fact>]
let ``folding a list`` () =
    let sequence = [ 4; -8; 9; 17; -5 ]
    // TODO: combine the numbers of the sequence by adding up.
    // Add another extra 20 when the number is negative.
    let result = 0

    Assert.Equal(57, result)

[<Fact>]
let ``filtering`` () =
    let letters =
        [ 'a'
          'b'
          'c'
          'd'
          'e'
          'f'
          'g'
          'h'
          'i'
          'j'
          'k'
          'l'
          'm'
          'n'
          'o'
          'p'
          'q'
          'r'
          's'
          't'
          'u'
          'v'
          'w'
          'x'
          'y'
          'z' ]

    let filtered = [] // TODO filter the list so only the vowels remain.

    Assert.Equal<char list>([ 'a'; 'e'; 'i'; 'o'; 'u'; 'y' ], filtered)

[<Fact>]
let ``filtering options`` () =
    let values =
        [ Some 8
          None
          Some 9
          None
          None
          Some 9
          Some 7
          None ]

    let filtered = [] // TODO: filter the values list so only the number remain (as int, not as int option).

    Assert.Equal<int list>([ 8; 9; 9; 7 ], filtered)

[<Fact>]
let ``pattern matching lists`` () =
    // TODO: create a recursive function that sums up all elements of list
    // Don't use any List module functions!
    // ref: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/functions/recursive-functions-the-rec-keyword
    let rec sumOfList current list = 0

    Assert.Equal(0, sumOfList 0 [])
    Assert.Equal(4, sumOfList 0 [ 4 ])
    Assert.Equal(7, sumOfList 0 [ 4; 3 ])
    Assert.Equal(13, sumOfList 0 [ 6; 6; 1 ])

[<Fact>]
let ``piping lists`` () =
    let lyrics =
        """
Hey Jude, don't make it bad
Take a sad song and make it better
Remember to let her into your heart
Then you can start to make it better
Hey Jude, don't be afraid
You were made to go out and get her
The minute you let her under your skin
Then you begin to make it better
And anytime you feel the pain
Hey Jude, refrain
Don't carry the world upon your shoulders
For well you know that it's a fool
Who plays it cool
By making his world a little colder
Na-na-na, na, na
Na-na-na, na
Hey Jude, don't let me down
You have found her, now go and get her (let it out and let it in)
Remember to let her into your heart (hey Jude)
Then you can start to make it better
So let it out and let it in
Hey Jude, begin
You're waiting for someone to perform with
And don't you know that it's just you
Hey Jude, you'll do
The movement you need is on your shoulder
Na-na-na, na, na
Na-na-na, na, yeah
Hey Jude, don't make it bad
Take a sad song and make it better
Remember to let her under your skin
Then you'll begin to make it better
Better better better better better, ah!
Na, na, na, na-na-na na (yeah! Yeah, yeah, yeah, yeah, yeah, yeah)
Na-na-na na, hey Jude
Na, na, na, na-na-na na
Na-na-na na, hey Jude
Na, na, na, na-na-na na
Na-na-na na, hey Jude
Na, na, na, na-na-na na
Na-na-na na, hey Jude (Jude Jude, Judy Judy Judy Judy, ow wow!)
Na, na, na, na-na-na na (my, my, my)
Na-na-na na, hey Jude (Jude, Jude, Jude, Jude, Jude)
Na, na, na, na-na-na na (yeah, yeah, yeah)
Na-na-na na, hey Jude (yeah, you know you can make it, Jude, Jude, you're not gonna break it)
Na, na, na, na-na-na na (don't make it bad, Jude, take a sad song and make it better)
Na-na-na na, hey Jude (oh Jude, Jude, hey Jude, wa!)
Na, na, na, na-na-na na (oh Jude)
Na-na-na na, hey Jude (hey, hey, hey, hey)
Na, na, na, na-na-na na (hey, hey)
Na-na-na na, hey Jude (now, Jude, Jude, Jude, Jude, Jude)
Na, na, na, na-na-na na (Jude, yeah, yeah, yeah, yeah)
Na-na-na na, hey Jude
Na, na, na, na-na-na na
Na-na-na na, hey Jude (na-na-na-na-na-na-na-na-na)
Na, na, na, na-na-na na
Na-na-na na, hey Jude
Na, na, na, na-na-na na
Na-na-na na, hey Jude
Na, na, na, na-na-na na (yeah, make it, Jude)
Na-na-na na, hey Jude (yeah yeah yeah yeah yeah! Yeah! Yeah! Yeah! Yeah!)
Na, na, na, na-na-na na (yeah, yeah yeah, yeah! Yeah! Yeah!)
Na-na-na na, hey Jude
Na, na, na, na-na-na na
Na-na-na na, hey Jude
Na, na, na, na-na-na na
Na-na-na na, hey Jude
Na, na, na, na-na-na na
Na-na-na na, hey Jude
"""

    let result = [] // TODO: create a list of the top ten words that occur the most in the lyric above.

    Assert.Equal<string list>(
        [ "na"
          "Jude"
          "hey"
          "yeah"
          "Na-na-na"
          "na-na-na"
          "it"
          "Na"
          "make"
          "better" ],
        result
    )
