abp install-libs

cd src/AppProduct.DbMigrator && dotnet run && cd -



cd src/AppProduct.Web && dotnet dev-certs https -v -ep openiddict.pfx -p config.auth_server_default_pass_phrase 


exit 0