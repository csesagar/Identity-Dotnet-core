<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

	<ItemGroup>
		<PackageReference Include="AutoMapper" Version="16.2.0" />
		<PackageReference Include="EntityFramework" Version="6.5.2" />
		<PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="10.0.13" />
		<PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="10.0.13" />
		<PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="10.0.13" />
		<PackageReference Include="Microsoft.EntityFrameworkCore" Version="10.0.13" />
		<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="10.0.13">
			<PrivateAssets>all</PrivateAssets>
			<IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
		</PackageReference>
		<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="10.0.13" />
		<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="10.0.13">
			<PrivateAssets>all</PrivateAssets>
			<IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
		</PackageReference>
		<PackageReference Include="System.Security.Cryptography.Pkcs" Version="9.0.21" />
		<PackageReference Include="Swashbuckle.AspNetCore" Version="10.3.1" />
	</ItemGroup>
</Project>
