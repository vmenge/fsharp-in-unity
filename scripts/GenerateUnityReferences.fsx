open System
open System.IO

let dllDirectory =
    @"C:\Program Files\Unity\Hub\Editor\2022.3.6f1\Editor\Data\PlaybackEngines\windowsstandalonesupport\Variations\win64_player_nondevelopment_il2cpp\Data\Managed"

let outputFile = Path.Combine("..", "References.props")

// Read the directory and filter DLLs
let dllFiles =
    Directory.GetFiles(dllDirectory, "*.dll")
    |> Array.map (fun fullPath -> Path.GetFileName(fullPath))

let buildPropsContent =
    let header = "<Project>\n    <ItemGroup>\n"
    let footer = "    </ItemGroup>\n</Project>\n"

    let dllEntries =
        dllFiles
        |> Array.map (fun dll ->
            let dllNameWithoutExtension = Path.GetFileNameWithoutExtension(dll)

            sprintf
                "        <Reference Include=\"%s\">\n            <HintPath>%s</HintPath>\n        </Reference>"
                dllNameWithoutExtension
                (Path.Combine(dllDirectory, dll)))

    String.concat "\n" (header :: (dllEntries |> Array.toList) @ [ footer ])

File.WriteAllText(outputFile, buildPropsContent)

printfn "Generated.References.props generated with %d references." dllFiles.Length
