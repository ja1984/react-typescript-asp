"use strict";

import React = require('react');

interface Props extends React.Props<App> {
	children?: any
}

class App extends React.Component<Props, {}> {
	render(): JSX.Element {
		return <div>{this.props.children}</div>;
	}
}

export = App;