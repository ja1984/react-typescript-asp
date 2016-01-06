module.exports = {
	cache: true,
	debug: true,
	entry: {
		app: './Scripts/main.tsx'
	},
	output: {
		filename: './wwwroot/js/site.js'
	},
	resolve: {
		extensions: ['', '.js', '.ts', '.tsx']
	},
	module: {
		loaders: [
			{
				test: /\.tsx?$/,
				loader: 'ts-loader'
			}
		]
	},
	noParse: [
		/[\/\\]node_modules.*/,
	]
}