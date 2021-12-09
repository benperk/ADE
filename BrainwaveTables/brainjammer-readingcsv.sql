-- pay attention to the schema reference [dbo], change when necessary

CREATE TABLE [dbo].[READINGCSV] (
    [TIMESTAMP]		NVARCHAR (50)	NOT NULL,
    [AF3theta]		DECIMAL(7,3)  	NOT NULL,
    [AF3alpha]		DECIMAL(7,3)  	NOT NULL,
    [AF3betaL]		DECIMAL(7,3)  	NOT NULL,
    [AF3betaH]		DECIMAL(7,3)  	NOT NULL,
    [AF3gamma]		DECIMAL(7,3)  	NOT NULL,
    [T7theta]		DECIMAL(7,3)  	NOT NULL,
    [T7alpha]		DECIMAL(7,3)  	NOT NULL,
    [T7betaL]		DECIMAL(7,3)  	NOT NULL,
    [T7betaH]		DECIMAL(7,3)  	NOT NULL,
    [T7gamma]		DECIMAL(7,3)  	NOT NULL,
    [Pztheta]		DECIMAL(7,3)  	NOT NULL,
    [Pzalpha]		DECIMAL(7,3)  	NOT NULL,
    [PzbetaL]		DECIMAL(7,3)  	NOT NULL,
    [PzbetaH]		DECIMAL(7,3)  	NOT NULL,
    [Pzgamma]		DECIMAL(7,3)  	NOT NULL,
    [T8theta]		DECIMAL(7,3)  	NOT NULL,
    [T8alpha]		DECIMAL(7,3)  	NOT NULL,
    [T8betaL]		DECIMAL(7,3)  	NOT NULL,
    [T8betaH]		DECIMAL(7,3)  	NOT NULL,
    [T8gamma]		DECIMAL(7,3)  	NOT NULL,
    [AF4theta]		DECIMAL(7,3)  	NOT NULL,
    [AF4alpha]		DECIMAL(7,3)  	NOT NULL,
    [AF4betaL]		DECIMAL(7,3)  	NOT NULL,
    [AF4betaH]		DECIMAL(7,3)  	NOT NULL,
    [AF4gamma]		DECIMAL(7,3)  	NOT NULL
);
