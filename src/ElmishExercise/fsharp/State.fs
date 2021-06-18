module ElmishExercise.State

open System
open System.Text.RegularExpressions
open ElmishExercise.Model

let init () : Model =
    { User = ""
      Email = ""
      Password = ""
      Errors = List.empty
      UserDidSubmit = false }

let private getUserNameError (value: string) =
    if String.IsNullOrWhiteSpace value then
        Some "Username cannot be empty"
    else
        None

let private getEmailError (value: string) =
    if value.Contains("@") then
        None
    else
        Some "Email should contain an @ symbol"

let private getPasswordError (value: string) =
    let regexDoesNotMatch regex = not (Regex.IsMatch(value, regex))

    if value.Length < 8 then
        Some "Password length should be 8 characters or longer"
    elif regexDoesNotMatch "[A-Z]" then
        Some "Password should contain a capital letter"
    elif regexDoesNotMatch "\d" then
        Some "Password should contain a number"
    else
        None

let update (msg: Msg) (model: Model) : Model =
    match msg with
    | UpdateUser user -> { model with User = user }
    | UpdateEmail email -> { model with Email = email }
    | UpdatePassword pw -> { model with Password = pw }
    | FormSubmit ->
        let errors =
            List.choose
                id
                [ getUserNameError model.User
                  getEmailError model.Email
                  getPasswordError model.Password ]

        { model with
              Errors = errors
              UserDidSubmit = true }
