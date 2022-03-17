SELECT
    ReadingDate, 
    AF3.THETA AS AF3THETA, AF3.ALPHA AS AF3ALPHA, 
    AF3.BETA_L AS AF3BETA_L, AF3.BETA_H AS AF3BETA_H, AF3.GAMMA AS AF3GAMMA,
    T7.THETA AS T7THETA, T7.ALPHA AS T7ALPHA, 
    T7.BETA_L AS T7BETA_L, T7.BETA_H AS T7BETA_H, T7.GAMMA AS T7GAMMA,
    Pz.THETA AS PzTHETA, Pz.ALPHA AS PzALPHA, Pz.BETA_L AS PzBETA_L,
    Pz.BETA_H AS PzBETA_H, Pz.GAMMA AS PzGAMMA,
    T8.THETA AS T8THETA, T8.ALPHA AS T8ALPHA, T8.BETA_L AS T8BETA_L,
    T8.BETA_H AS T8BETA_H, T8.GAMMA AS T8GAMMA,
    AF4.THETA AS AF4THETA, AF4.ALPHA AS AF4ALPHA, AF4.BETA_L AS AF4BETA_L,
    AF4.BETA_H AS AF4BETA_H, AF4.GAMMA AS AF4GAMMA
INTO
    [YourOutputAlias]
FROM
    [YourInputAlias]