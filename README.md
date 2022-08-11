# TestingVault

Для начала запускаем в терминале команду `docker pull vault` для поддержки vault.

Создаем контейнер с Vault командой `docker run --name vault -p 8200:8200 vault:latest`.

Результатом команды в консоли будет выведено следующее:
> You may need to set the following environment variable:
> 
>     $ export VAULT_ADDR='http://0.0.0.0:8200'
> 
> The unseal key and root token are displayed below in case you want to
> seal/unseal the Vault or re-authenticate.
> 
> Unseal Key: TkSC74J0vzClvql9IEUJwdHvtyL+gLybyWWk0DWQ7zU=
> Root Token: hvs.pbqnPGi3Y5I44FK4rlGAZxCF
> 
> Development mode should NOT be used in production installations!

Скопируйте токен из RootToken в [appsittegs.json](https://github.com/altamir95/TestingVault/blob/main/TestingVault/TestingVault/appsettings.json) полю `VaultToken`.

**В терминале контейнера** который мы создали ранее запускаем команду `export VAULT_ADDR='http://0.0.0.0:8200'`.

Так же **в терминале контейнера** вводим команду `export VAULT_TOKEN='токен из RootToken'` для того что бы не логиниться.

Далее **в терминале контейнера** введите команду `Vault kv put secret/tdc tdcpassword=test1234` для создания секретного ключа.
