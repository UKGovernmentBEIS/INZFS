#!/bin/bash

grafana-server \
 --homepath="$GF_PATHS_HOME" \
 --config="$GF_PATHS_CONFIG" \
 cfg:default.paths.data="$GF_PATHS_DATA" &
sleep 10 &&

curl \
 -XPOST \
 -H "Content-Type: application/json" \
 -d '{ "name":"viewer", "email":"viewer@org.com", "login":"viewer",  "password":"readonly" }' \
 http://admin:admin@https://inzfs-prom-grafana.london.cloudapps.digital/api/admin/users 

curl \
 -X PUT \
 -H 'Content-Type: application/json' \
 -d '{ "homeDashboardId":4 }' \
 http://viewer:readonly@localhost:3000/api/user/preferences
