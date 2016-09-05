require("babel-polyfill");
require("bootstrap-webpack");

require("file?name=index.html!index.html");
require("file?name=favicon.png!favicon.png");

require("style.styl");

require("Main").main();
