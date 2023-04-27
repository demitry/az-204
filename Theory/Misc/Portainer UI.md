<https://linux.how2shout.com/how-to-install-portainer-docker-web-gui/>
<https://docs.portainer.io/start/install/server/docker/linux>

sudo docker run -d -p 8000:8000 -p 9000:9000 --name=portainer --restart=always -v /var/run/docker.sock:/var/run/docker.sock -v portainer_data:/data portainer/portainer-ce

sudo docker ps

42a2e5751f8f

allow port 9000 in vm rules

http://host-ip:9000/
http://168.63.57.194:9000/

New Portainer installation
Your Portainer instance timed out for security purposes. To re-enable your Portainer instance, you will need to restart Portainer.

sudo docker stop 42a
sudo docker start 42a

http://168.63.57.194:9000/ = Page = Please create the initial administrator user.

admin/password
