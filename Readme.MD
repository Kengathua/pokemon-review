    CREATE DATABASE pokemon_db;

    CREATE USER pokemon_user WITH SUPERUSER CREATEDB CREATEROLE LOGIN PASSWORD 'pokemon_pass';

    ALTER ROLE pokemon_user SET client_encoding TO 'utf8';

    ALTER ROLE pokemon_user SET default_transaction_isolation TO 'read committed';

    ALTER ROLE pokemon_user SET timezone TO 'UTC';

    GRANT ALL PRIVILEGES ON DATABASE pokemon_db TO pokemon_user;

    CREATE DATABASE pokemon_test;

    GRANT ALL PRIVILEGES ON DATABASE pokemon_test TO pokemon_user;

    \q