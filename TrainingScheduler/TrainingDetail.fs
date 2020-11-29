namespace TrainingScheduler

open Fabulous
open Fabulous.XamarinForms
open TrainingScheduler.Models

module TrainingDetail =

    type Msg =
        | DeleteTraining
        | SaveTraining