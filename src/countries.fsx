#r "nuget: FSharp.Data, 4.0.1"

open FSharp.Data

let url = "https://restcountries.eu/rest/v2/all"

type CountryProvider =
    JsonProvider<"""
[{
    "name": "Afghanistan",
    "topLevelDomain": [".af"],
    "alpha2Code": "AF",
    "alpha3Code": "AFG"
}]
""">

let countriesFromWeb = CountryProvider.Load(url)

let countriesStartWith (letter: char) =
    query {
        for country in countriesFromWeb do
            where (country.Name.StartsWith(letter))
            select country.Name
    }
    |> Seq.toArray

countriesStartWith 'B'
