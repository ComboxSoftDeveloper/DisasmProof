@echo off
cd /d %~dp0

dotnet build -c Release

set DOTNET_JitDisasm=*SumOverInterface*

bin\Release\net10.0\DisasmProof.exe > disasm_net10.txt 2>&1
bin\Release\net8.0\DisasmProof.exe > disasm_net8.txt 2>&1

set DOTNET_JitDisasm=

echo.
echo Gotovo. Zabiray disasm_net10.txt i disasm_net8.txt iz etoy papki.
pause
