module ElmishExercise.State

open ElmishExercise.Model

let init () : Model =
    { User = ""
      Email = ""
      Password = ""
      Errors = List.empty
      UserDidSubmit = false }

let update (msg: Msg) (model: Model) : Model = model
