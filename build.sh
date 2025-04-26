#! /bin/bash 

git submodule update --init --recursive
git submodule foreach git pull origin master

cd lucide 
pnpm install 

pnpm run build:outline-icons
pnpm run build:font 


cd ..

node ./gen-codepoints.js