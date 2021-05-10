module ElmishExercise.App

open Elmish
open ElmishExercise

(*
    Complete the form:
        - give feedback when there is invalid input (display errors)
        - username should not be empty
        - email should be valid
        - password should have a capital letter, a number and be 8 chars long
*)

open Elmish.React

Program.mkSimple State.init State.update View.view
|> Program.withReactBatched "root"
|> Program.run
