namespace fs

open UnityEngine

type TestBehaviour() =
    inherit MonoBehaviour()

    [<SerializeField>]
    let mutable testField = 0

    member this.Start() = Debug.Log "hello from f#"
