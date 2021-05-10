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

#r "nuget: SQLProvider, 1.2.1"
#r "nuget: Npgsql, 5.0.4"

// Postgres docker image:
// docker run --rm --name countries-db -p "5432:5432" -e POSTGRES_DB=countries -e POSTGRES_PASSWORD=countriesSecretPassword1 -d postgres

open FSharp.Data.Sql

[<Literal>]
let dbVendor = Common.DatabaseProviderTypes.POSTGRESQL

[<Literal>]
let connString =
    "User ID=postgres;Password=countriesSecretPassword1;Host=localhost;Port=5432;Database=countries"

type CountryDbProvider = SqlDataProvider<DatabaseVendor=dbVendor, ConnectionString=connString, Owner="public">

let context = CountryDbProvider.GetDataContext()

let initializeDatabase () =
    let conn = context.CreateConnection()
    conn.Open()
    let cmd = conn.CreateCommand()

    cmd.CommandText <-
        """
CREATE TABLE IF NOT EXISTS countries (
   id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
   name TEXT,
   iso03266A2 TEXT
);
"""

    cmd.ExecuteNonQuery() |> ignore
    conn.Dispose()
    printfn "database schema created!"

let deleteAllCountries () =
    let conn = context.CreateConnection()
    conn.Open()
    let cmd = conn.CreateCommand()
    cmd.CommandText <- "DELETE FROM countries;"
    cmd.ExecuteNonQuery() |> ignore
    conn.Dispose()
    printfn "all countries were deleted"

let syncCountries () =
    countriesFromWeb
    |> Array.map
        (fun country ->
            let countryRow = context.Public.Countries.Create()
            countryRow.Name <- country.Name
            countryRow.Iso03266a2 <- country.Alpha2Code)
    |> fun _ -> context.SubmitUpdates()

let countriesStartWith (letter: char) =
    query {
        for country in context.Public.Countries do
            where (country.Name.StartsWith(letter))
            select country.Name
    }
    |> Seq.toArray

initializeDatabase ()
deleteAllCountries ()
syncCountries ()
countriesStartWith 'B'
