
import { defineConfig } from 'vite';
import { resolve } from 'node:path';

export default defineConfig({
    build: {
        rollupOptions: {
            input: {
                main: resolve(__dirname, 'wwwroot/js/main.js')
            },
            output: {
                entryFileNames: 'js/[name].js',
                chunkFileNames: 'js/[name]-[hash].js',
                assetFileNames: '[name][extname]'
            }
        },
        outDir: 'wwwroot/dist',
        emptyOutDir: true
    }
});
