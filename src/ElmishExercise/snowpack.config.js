/** @type {import("snowpack").SnowpackUserConfig } */
module.exports = {
  mount: {
    public: { url: '/', static: true },
    src: { url: '/dist' },
  },
  plugins: [
    '@snowpack/plugin-react-refresh',
    '@snowpack/plugin-dotenv',
    ["@snowpack/plugin-run-script", {
      "cmd": "echo 'Fable already built'",
      "watch": "dotnet fable watch ./fsharp/ElmishExercise.fsproj --outDir ./src/bin"
    }]
  ],
  routes: [
    /* Enable an SPA Fallback in development: */
    // {"match": "routes", "src": ".*", "dest": "/index.html"},
  ],
  optimize: {
    /* Example: Bundle your final build: */
    // "bundle": true,
  },
  packageOptions: {
    /* ... */
  },
  devOptions: {
    output: "stream",
    hmrPort: 443
  },
  buildOptions: {
    /* ... */
  },
};
