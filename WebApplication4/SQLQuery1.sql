SET LANGUAGE russian
CREATE TABLE article(
id INT NOT NULL PRIMARY KEY IDENTITY,
title VARCHAR (1000) NOT NULL,
author VARCHAR (150) NOT NULL,
create_data DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP

);

INSERT INTO article(title, author)
VALUES
('«Судьба/Странная подделка: Шёпот рассвета» не выйдет на Новый год','Валера Татарян'),
('Самые продаваемые ранобэ в Японии за 2022 год','Альбина Алдабергенова'),
(' Самая продаваемая манга в Японии за 2022 год','Никита Егоров'),
(' Аниме «Судзуме, закрывающая двери» Макото Синкая стало четвёртым по кассовости фильмом японского проката в 2022 году','София Ульянова'),
(' Продолжение аниме-сериала «Путь домохозяина» обзавелось датой премьеры на Netflix','Дима Карпов'),
('«Пуля» — анонс аниме от режиссёра «Магической битвы»','Сiнхо Паu')