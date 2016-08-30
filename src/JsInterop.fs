namespace Playground

open Fable.Core
open Fable.Import

module Js =
    open Fable.Core.JsInterop

    let inline get name o = o ? (name) :> obj
    let inline set name v o = o ? (name) <- v
    let inline call name args o = (o ? (name)) args
    let inline apply args o = o $ args
    let inline cast<'a> (o: obj) = o :?> 'a

    let inline empty () = createEmpty ()
    let inline newmap fields = createObj fields
    let inline newobj o args = createNew o args

    let inline expect<'a> (x: 'a) = x

module Option = 
    let def v o = defaultArg o v
    let alt a o = match o with | None -> a | _ -> o
