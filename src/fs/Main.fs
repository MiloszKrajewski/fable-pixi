namespace Playground

open System
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import

module Main =
    let bunnyUrl = importDefault<string> "bunny.png"

    let rec animate (stage: PIXI.Container) (renderer: PIXI.CanvasRenderer) (bunny: PIXI.Sprite) =
        bunny.rotation <- bunny.rotation + 0.01 
        renderer.render stage |> ignore
        Browser.window.requestAnimationFrame(fun _ -> animate stage renderer bunny) |> ignore

    let main () =
        let renderer = PIXI.CanvasRenderer (800.0, 600.0) 
        let loader = PIXI.Globals.loader
        Browser.document.body.appendChild(renderer.view) |> ignore

        let stage = PIXI.Container ()

        loader
            .add("bunny", bunnyUrl)
            .load(Func<_,_,_>(fun l r ->
                let getTexture name = r ? (name) ? texture |> unbox<PIXI.Texture>
                let newSprite texture = PIXI.Sprite(texture)

                let bunny = getTexture "bunny" |> newSprite

                bunny.position.x <- 400.0
                bunny.position.y <- 300.0
                bunny.scale.x <- 2.0
                bunny.scale.y <- 2.0
                stage.addChild(bunny) |> ignore
                animate stage renderer bunny
            ))
