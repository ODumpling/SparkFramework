import { defineConfig } from "vite";
import vue from "@vitejs/plugin-vue";
import appsettings from "./appsettings.json";
import path from "path";

export default defineConfig({
  plugins: [
    vue({
      template: {
        transformAssetUrls: {
          base: null,
          includeAbsolute: false,
        },
      },
    }),
  ],
  resolve: {
    alias: {
      "@": path.resolve(__dirname, "./Resources/Js"),
    },
  },
  build: {
    outDir: `./wwwroot/${appsettings.Vite.Build.OutputDir}`,
    rollupOptions: {
      input: "./Resources/Js/app.js",
      output: {
        entryFileNames: `[name].js`,
        chunkFileNames: `[name].js`,
        assetFileNames: `[name].[ext]`,
      },
    },
  },
  server: {
    host: "localhost",
    port: appsettings.Vite.Port,
  },
});
