"use strict";

import React = require('react');
var Router = require('react-router');

var Route = Router.Route;
var IndexRoute = Router.IndexRoute;

import App = require('./app.tsx');
import HomePage = require('./homePage.tsx');


var routes = (
	<Route path="/" component={App}>
		<IndexRoute component={HomePage} />
	</Route>
);

export = routes;