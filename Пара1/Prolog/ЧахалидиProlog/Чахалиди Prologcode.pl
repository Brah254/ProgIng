% Правила для определения расположения и интересов каждого филателиста

% Волк собирает фауну.
collects(wolf, fauna).

% Один из поросят собирает флору.
collects(nif, flora).
collects(naf, _).
collects(nuf, _).

% Один из поросят собирает спорт, и другой собирает космос.
collects(nif, _).
collects(naf, sport).
collects(nuf, cosmos).

% Правила для определения расположения каждого филателиста

% Волк сидит слева от Нафа.
left_of(wolf, naf).

% Ниф сидит справа от собирателя космоса.
right_of(nif, Collector) :-
    collects(Collector, cosmos).

% Нуф сидит напротив Нафа.
opposite(nuf, naf).
opposite(naf, nuf).

% Ниф сидит напротив Волка.
opposite(nif, wolf).
opposite(wolf, nif).
opposite_of(Collector1, Collector2) :-
    opposite(Collector1, Collector2);
    opposite(Collector2, Collector1).

% Правило для запроса и вывода итогового ответа.
query :-
    collects(Collector, Collects),
    opposite_of(Collector, OppositeCollector),
    write('Collector: '), write(Collector), nl,
    write('Collects: '), write(Collects), nl,
    write('Opposite Collector: '), write(OppositeCollector), nl.
