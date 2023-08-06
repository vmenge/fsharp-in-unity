# fsharp in unity

Small sample on how to get F# working with Unity3D without any issues. Mostly done by following [this tutorial](youtube.com/watch?v=sK6BUkQE5U4) by [@7sharp9](https://github.com/7sharp9).

## Steps
1 - Clone this into the folder of your project on the same level as the `Assets` folder
```bash
MyUnityProject/
├─ Assets/
├─ Packages/
├─ fs/
# etc
```
2 - Edit the `scripts/GenerateUnityReferences.fsx` to point to the proper directory on your computer and the property Unity version.

3 - Run `GenerateUnityReferences.fsx`

This will create a `Generated.References.props` file inside your `fs` folder. This file is referenced by `fs.fsproj` and will allow you to use all Unity packages within your F# package.
Now you can just `dotnet watch build` and have your F# assembly copied over to the `/Assets` folder every time you build 🥳

**NOTE: You might have to manually right click the `Assets` folder under the Project tab in Unity and choose `Refresh` for changes to be detected`.**
