module ElmishExercise.Model

type Model =
    { User: string
      Email: string
      Password: string
      Errors: string list
      UserDidSubmit: bool }

type Msg =
    | UpdateUser of string
    | UpdateEmail of string
    | UpdatePassword of string
    | FormSubmit
