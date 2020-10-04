# Simple config class

## How to Load/Save (default config file path : Documents)

```csharp
string file_name = "settings";

// for Load
Config.Load(file_name); 

// for Save
Config.Save(file_name);
```

## How to Get/Set value

```csharp
// for set value
Config.SetValue<string>("example", "example text");

// for get value
string Output = Config.GetValue<string>("example");
/*
    Output : example text
*/
```

## Example usage

```csharp
Config.SetValue<string>("example", "example text");
Config.SetValue<int>("example-number", 256);

Config.Save("settings");
```

## Example usage / Output
![alt text](https://github.com/Lufzy/Simple-Config/blob/main/example-1.PNG?raw=true)

## License
[MIT](https://choosealicense.com/licenses/mit/)
