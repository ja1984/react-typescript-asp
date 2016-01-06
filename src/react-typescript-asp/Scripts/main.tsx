"use strict";

import React = require('react');

var ReactDOM = require('react-dom');
var ReactRouter = require('react-router');
var history = require('./history');

var Router = ReactRouter.Router;
var Route = ReactRouter.Route;

var Route = Router.Route;
var IndexRoute = Router.IndexRoute;

import Routes = require('./routes.tsx');

ReactDOM.render((
	<Router routes={Routes} history={history} />
), document.getElementById('app-container'));