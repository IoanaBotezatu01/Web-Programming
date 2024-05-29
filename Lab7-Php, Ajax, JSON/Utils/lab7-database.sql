create table recipe (
    recipeID    int          not null primary key AUTO_INCREMENT,
    rauthor     varchar(100) not null,
    rname       varchar(100) not null,
    rtype       varchar(100) not null,
    ringredients varchar(100) not null,
    rinstructions varchar(100) not null,
    rimage      varchar(100) not null
);
select * from recipe;

INSERT INTO recipe (rauthor, rname, rtype, ringredients, rinstructions, rimage) VALUES
('John Doe', 'Spaghetti Bolognese', 'Italian', 'Spaghetti, beef, tomato sauce', 'Cook spaghetti, prepare sauce, mix together', 'spaghetti.jpg'),
('Jane Smith', 'Chicken Curry', 'Indian', 'Chicken, curry sauce, rice', 'Cook chicken, prepare curry sauce, serve with rice', 'chicken_curry.jpg'),
('Alice Johnson', 'Chocolate Cake', 'Dessert', 'Flour, cocoa, sugar, eggs', 'Mix ingredients, bake in oven', 'chocolate_cake.jpg'),
('Michael Brown', 'Caesar Salad', 'Salad', 'Lettuce, croutons, parmesan, Caesar dressing', 'Mix ingredients, add dressing, serve', 'caesar_salad.jpg'),
('Emily Davis', 'Beef Tacos', 'Mexican', 'Beef, taco shells, lettuce, cheese, salsa', 'Cook beef, assemble tacos with ingredients', 'beef_tacos.jpg');