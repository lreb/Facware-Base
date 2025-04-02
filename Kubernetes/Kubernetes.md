# install kubernetes

[Instruction to install kubernetes](https://kubernetes.io/docs/tasks/tools/)

## Validate kubectl

```bash
kubectl version --client
kubectl version --client --output=yaml
```

## Install kubectl

[Instruction to install minikube](https://minikube.sigs.k8s.io/docs/start/?arch=%2Flinux%2Fx86-64%2Fstable%2Fbinary+download)

### minikube dashboard

```bash
minikube dashboard
```

terminal will display dashboard local url

```bash

## common commands

### Cluster Information

Check cluster information:

```bash
Cluster Information
```

List all nodes in the cluster:

```bash
kubectl get nodes
```

Namespaces
List all namespaces:

```bash
kubectl get namespaces
```

Create a new namespace:

```bash
kubectl create namespace <namespace-name>
```

Switch to a specific namespace:

```bash
kubectl config set-context --current --namespace=<namespace-name>
```

### Pods

List all pods in the current namespace:

```bash
kubectl get pods
```

List all pods in a specific namespace:

```bash
kubectl get pods -n <namespace-name>
```

Describe a specific pod:

```bash
kubectl describe pod <pod-name>
```

View logs of a pod:

```bash
kubectl logs <pod-name>
```

Execute a command inside a pod:

```bash
kubectl exec -it <pod-name> -- <command>
```

### Deployments

List all deployments:

```bash
kubectl get deployments
```

Create a deployment:

```bash
kubectl create deployment <deployment-name> --image=<image-name>
```

Scale a deployment:

```bash
kubectl scale deployment <deployment-name> --replicas=<number>
```

Update a deployment:

```bash
kubectl set image deployment/<deployment-name> <container-name>=<new-image>
```

Delete a deployment:

```bash
kubectl set image deployment/<deployment-name> <container-name>=<new-image>
```

### Services

List all services:

```bash
kubectl get services
```

Expose a deployment as a service:

```bash
kubectl expose deployment <deployment-name> --type=<service-type> --port=<port>
```

Delete a service:

```bash
kubectl delete service <service-name>
```

### ConfigMaps and Secrets

Create a ConfigMap

```bash
kubectl create configmap <configmap-name> --from-literal=<key>=<value>
```

Create a Secret:

```bash
kubectl create secret generic <secret-name> --from-literal=<key>=<value>
```

View ConfigMaps:

```bash
kubectl get configmaps
```

View Secrets

```bash
kubectl get secrets
```

### Apply and Delete Resources

Apply a configuration file:

```bash
kubectl apply -f <file.yaml>
```

Delete a resource using a configuration file:

```bash
kubectl delete -f <file.yaml>
```

### Debugging

View events in the cluster:

```bash
kubectl get events
```

Debug a pod:

```bash
kubectl describe pod <pod-name>
```

Debug a pod:

```bash
kubectl describe pod <pod-name>
```

View detailed logs:

```bash
kubectl logs <pod-name> -c <container-name>
```
