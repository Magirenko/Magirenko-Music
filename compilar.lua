print("Compilador CLI De Magirenko v0.1\n\nSoftware a compilar: Magirenko Music\nNota: Esto solo compilara el software, lo compilado no es igual al producto final en las descargas.\nSi vas a usar el software, se recomienda que uses los de las descargas de los releases.\n\n")
while true do
  local optimizacion = "Debug"
  local autocontenido = false
  print("Magirenko Music se compilara en la carpeta bin\nQuieres compilar Magirenko Music? (y/n)")
  local response = io.read()
  if response == "y" then
    print("- Configuracion -")
    print("Modo de optimizacion de .NET:\na) Debug\nb) Release\n(a/b)")
    local response2 = io.read()
    if response2 == "a" then
      optimizacion = "Debug"
    elseif response2 == "b" then
      optimizacion = "Release"
    end
    print("Modo de Optimizacion Seleccionado: " .. optimizacion)

    print("Autocontenido? (y/n)")
    local response3 = io.read()
    if response3 == "y" then
      autocontenido = true
    elseif response3 == "n" then
      autocontenido = false
    end
    print("Autocontenido:" .. tostring(autocontenido))
    print("Magirenko Music esta listo para compilarse.\nCompilando...")
    os.execute("dotnet build --self-contained ".. tostring(autocontenido) .. " -c ".. optimizacion)
    break
  elseif response == "n" then
    break
  end
end
